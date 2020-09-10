using Plugin.Media;
using Plugin.Media.Abstractions;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Wongoo_Application.Shared
{
   public class MobileCamera
    {
		public string ServerURL = ServerIP.IP;
		public string ImageUploadEndPoint = "/api/application/products/imagesupload";
		ResponseMessage ResponseMessage = new ResponseMessage();

		public async Task<ResponseMessage> TakePhoto(string FileName,string FieldName)
        {

			await CrossMedia.Current.Initialize();
			if (!CrossMedia.Current.IsPickPhotoSupported || !CrossMedia.Current.IsTakePhotoSupported)
			{

				ResponseMessage.Message = "Camera not supported by this device";
				ResponseMessage.Title = "Failed";
				return ResponseMessage;
			}
			else
			{
				var url = ServerURL + ImageUploadEndPoint;
				var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
				{
					Directory = "Wongoo",
					Name = FileName,
					CompressionQuality = 30,
					PhotoSize = PhotoSize.Small,
					AllowCropping = true
				});
				if (file == null) {
					ResponseMessage.Message = "File not found,please try again later.";
					ResponseMessage.Title = "Failed";
					return ResponseMessage;
				}
				StreamContent scontent = new StreamContent(file.GetStream());
				scontent.Headers.ContentDisposition = new ContentDispositionHeaderValue("form-data")
				{
					FileName = FileName+".jpg",
					Name = FieldName
				};
				scontent.Headers.ContentType = new MediaTypeHeaderValue("image/jpeg");

				var client = new HttpClient();
				var multi = new MultipartFormDataContent();
				multi.Add(scontent);
				var Token =await UserInfo.GetToken();
				client.DefaultRequestHeaders.Add("auth-token", Token);
				var result = client.PostAsync(url, multi).Result;
				string response = await result.Content.ReadAsStringAsync();
				ResponseMessage.Message = response;
				ResponseMessage.Title = "Success";
				ResponseMessage.Status = true;
				return ResponseMessage;
			}
		}
    }
	public  class ResponseMessage
	{
		public ResponseMessage()
		{
			Status= false;
		}
		public bool Status { get; set; }
		public  string Title { get; set; }
		public  string Message { get; set; }
	}
}
