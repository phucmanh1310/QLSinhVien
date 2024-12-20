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
            // Tạo cột từ các field của document đầu tiên (bỏ qua _id)
            foreach (var field in documents[0].Elements)
            {
                if (field.Name != "_id") // Bỏ qua cột _id
                {
                    table.Columns.Add(field.Name, typeof(string));
                }
            }

            // Thêm dữ liệu từ các document
            foreach (var doc in documents)
            {
                DataRow row = table.NewRow();
                foreach (var field in doc.Elements)
                {
                    if (field.Name != "_id") // Bỏ qua _id
                    {
                        row[field.Name] = ConvertBsonValueToString(field.Value);
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
            if (value.IsBsonDateTime)
                return value.ToUniversalTime().ToString("yyyy-MM-dd"); // Format ngày tháng

            if (value.IsBsonDocument)
                return value.ToJson(); // Tránh lỗi khi dữ liệu là một BsonDocument

            if (value.IsBsonArray)
                return string.Join(", ", value.AsBsonArray.Select(x => ConvertBsonValueToString(x)));

            if (value.IsBoolean)
            {
                // Chuyển Boolean thành chuỗi rõ ràng hơn
                return value.AsBoolean ? "True" : "False";
            }

            if (value.BsonType == BsonType.Document)
            {
                // Tránh lỗi nếu gặp nested Document
                return value.ToJson();
            }

            if (value.IsNumeric)
                return value.ToDouble().ToString();

            return value.ToString();
        }
        catch (Exception ex)
        {
            // Ghi lại lỗi và trả về chuỗi rỗng để tránh crash
            Console.WriteLine($"Error converting BsonValue: {ex.Message}");
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
