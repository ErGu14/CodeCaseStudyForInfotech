using Commercium.Shared.Other.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commercium.Service.Interfaces
{
    public interface IFileService
    {
        Task<string> UploadFileAsync(IFormFile file, FileType fileType);
    }
}
