namespace Ciber.Models
{
    public class ServiceResult
    {
        /// <summary>
        /// Dữ liệu trả ra
        /// </summary>
        public object Data { get; set; }
        /// <summary>
        /// Trạng thái
        /// </summary>

        public string Code { get; set; }
        /// <summary>
        /// Thông báo
        /// </summary>

        public string Message { get; set; }
        /// <summary>
        /// Mã lỗi
        /// </summary>

        public int? ErrorCode { get; set; }
        
       
    }
}
