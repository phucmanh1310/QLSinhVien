using System.Data;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;

public static class DataConversion1
{
    public static DataTable ConvertToDataTable1(List<BsonDocument> documents)
    {
        DataTable table = new DataTable();

        if (documents != null && documents.Count > 0)
        {
            // Tạo cột từ các field của document đầu tiên (bỏ qua _id)
            foreach (var field in documents[0].Elements)
            {
                if (field.Name != "_id")
                    table.Columns.Add(field.Name, typeof(string));
            }

            // Thêm dữ liệu từ các document
            foreach (var doc in documents)
            {
                DataRow row = table.NewRow();
                foreach (var field in doc.Elements)
                {
                    if (field.Name != "_id")
                        row[field.Name] = ConvertBsonValueToString(field.Value);
                }
                table.Rows.Add(row);
            }
        }

        return table;
    }

    private static string ConvertBsonValueToString(BsonValue value)
    {
        if (value == null || value.IsBsonNull)
            return string.Empty;

        try
        {
            if (value.IsBsonDocument)
                return value.ToJson(); // Chuyển thành JSON string

            if (value.IsBsonArray)
                return string.Join(", ", value.AsBsonArray.Select(x => ConvertBsonValueToString(x)));

            if (value.IsBoolean)
                return value.AsBoolean.ToString();

            if (value.IsNumeric)
                return value.ToDouble().ToString();

            return value.ToString();
        }
        catch
        {
            return string.Empty; // Tránh ngoại lệ, trả về chuỗi rỗng
        }
    }

}
