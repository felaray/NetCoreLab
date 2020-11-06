using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FileApi.Models
{
    public class Files
    {
        /// <summary>
        /// 檔案id
        /// </summary>
        public Guid Id { get; set; }
        /// <summary>
        /// 檔案名稱
        /// </summary>
        /// <example>
        /// Test
        /// </example>
        public string FileName { get; set; }
        /// <summary>
        /// 檔案大小'
        /// </summary>
        /// <example>
        /// 1000
        /// </example>
        public long FileSize { get; set; }
        /// <summary>
        /// 檔案類型
        /// </summary>
        public string FileType { get; set; }
        /// <summary>
        /// 檔案時間
        /// </summary>
        public DateTimeOffset CreateDateTime { get; set; }
    }
}
