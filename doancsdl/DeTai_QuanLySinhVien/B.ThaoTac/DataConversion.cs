using System.Data;
using System.Collections.Generic;
using MongoDB.Bson;
using System.Linq;

namespace B.ThaoTac
{
    public static class DataConversion1
    {
        public static DataTable ConvertToDataTable1(List<BsonDocument> documents)
        {
            DataTable table = new DataTable();

            if (documents != null && documents.Count > 0)
            {
                // Tạo cột từ các field, bỏ qua trường "_id"
                foreach (var field in documents[0].Elements)
                {
                    if (field.Name != "_id") // Bỏ qua trường _id
                        table.Columns.Add(field.Name, typeof(string));
                }

                // Thêm dữ liệu từ BsonDocument
                foreach (var document in documents)
                {
                    DataRow row = table.NewRow();
                    foreach (var field in document.Elements)
                    {
                        if (field.Name != "_id") // Bỏ qua trường _id
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
                return string.Empty; // Trả về chuỗi rỗng nếu null

            try
            {
                if (value.IsBsonArray)
                    return string.Join(", ", value.AsBsonArray.Select(x => x.ToString()));

                if (value.IsBsonDocument)
                    return value.AsBsonDocument.ToJson(); // Chuyển thành JSON string

                if (value.IsBoolean)
                    return value.AsBoolean.ToString(); // Chuyển đổi Boolean sang string

                if (value.IsNumeric)
                    return value.ToDouble().ToString(); // Chuyển số sang chuỗi

                return value.ToString(); // Chuyển tất cả kiểu khác về string
            }
            catch
            {
                return string.Empty; // Trả về chuỗi rỗng nếu có lỗi
            }
        }
    }
}
