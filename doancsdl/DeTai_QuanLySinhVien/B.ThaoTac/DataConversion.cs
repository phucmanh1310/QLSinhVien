using System.Data;
using MongoDB.Bson;
using System.Linq;
using System.Collections.Generic;
using System;

public static class DataConversion1
{
    public static DataTable ConvertToDataTable1(List<BsonDocument> documents)
    {
        DataTable table = new DataTable();

        if (documents != null && documents.Count > 0)
        {
            // Tạo cột từ document đầu tiên, bỏ qua cột "_id"
            foreach (var field in documents[0].Elements)
            {
                if (field.Name != "_id" && !table.Columns.Contains(field.Name))
                    table.Columns.Add(field.Name, typeof(string));
            }

            // Thêm dữ liệu từ các document
            foreach (var doc in documents)
            {
                DataRow row = table.NewRow();

                foreach (var field in doc.Elements)
                {
                    if (field.Name != "_id") // Bỏ qua cột "_id"
                    {
                        try
                        {
                            row[field.Name] = ConvertBsonValueToString(field.Value);
                        }
                        catch
                        {
                            row[field.Name] = string.Empty; // Tránh lỗi
                        }
                    }
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
            switch (value.BsonType)
            {
                case BsonType.DateTime:
                    return value.ToUniversalTime().ToString("yyyy-MM-dd");
                case BsonType.Array:
                    return string.Join(", ", value.AsBsonArray.Select(x => ConvertBsonValueToString(x)));
                case BsonType.Boolean:
                    return value.AsBoolean.ToString();
                case BsonType.Document:
                    return value.ToJson();
                case BsonType.Double:
                    return value.AsDouble.ToString();
                case BsonType.Int32:
                    return value.AsInt32.ToString();
                case BsonType.Int64:
                    return value.AsInt64.ToString();
                default:
                    return value.ToString();
            }
        }
        catch
        {
            return string.Empty;
        }
    }

    // Chuyển đổi BsonDateTime thành DateTime
    public static DateTime ConvertBsonDateTimeToDateTime(BsonValue value)
    {
        if (value == null || value.IsBsonNull)
            return DateTime.MinValue; // Trả về giá trị mặc định cho DateTime

        try
        {
            if (value.IsBsonDateTime)
                return value.ToUniversalTime(); // Chuyển thành kiểu DateTime

            return DateTime.MinValue; // Trả về mặc định nếu không phải DateTime
        }
        catch (Exception)
        {
            return DateTime.MinValue; // Tránh ngoại lệ
        }
    }

}
