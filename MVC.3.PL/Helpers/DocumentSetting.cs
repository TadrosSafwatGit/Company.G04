namespace MVC._3.PL.Helpers
{
    public static class DocumentSetting
    {

        // 1 - upload

        public static string UploadFile(IFormFile file, string folderName) 
        {
            //1- get folder  location 
            //string folderPath = "C:\\Users\\tadd\\source\\repos\\Company.G04\\MVC.3.PL\\wwwroot\\files\\"+folderName;

            //var folderPath=  Directory.GetCurrentDirectory()+ "\\wwwroot\\files\\"+folderName;

            var folderPath = Path.Combine(Directory.GetCurrentDirectory() , @"wwwroot\files" , folderName);

            //2- Get  FileName and Make It Unique 

            var fileName = $"{Guid.NewGuid()}{file.FileName}";

            // file Path

            var filePath=Path.Combine(folderPath, fileName);

            using var fileStream = new FileStream(filePath,FileMode.Create);

            file.CopyTo(fileStream);

            return fileName;
        }
        // 2- Delete

        public static void DeleteFile(string fileName,string folderName)
        {


            var filePath = Path.Combine(Directory.GetCurrentDirectory() , @"wwwroot\files", folderName,fileName);

            if (File.Exists(filePath)) 
            File.Delete(filePath);
           


        }


    }
}
