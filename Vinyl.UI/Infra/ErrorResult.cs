using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace Vinyl.UI.Infra
{
	public class ErrorResult : IHttpActionResult
	{
		Error _error;
		HttpRequestMessage _request;

		public ErrorResult(Error error, HttpRequestMessage request)
		{
			_error = error;
			_request = request;
		}

		Task<HttpResponseMessage> IHttpActionResult.ExecuteAsync(CancellationToken cancellationToken)
		{
			List<Error> _errorList = new List<Error>();
			_errorList.Add(_error);

			error err = new error()
			{
				errors = _errorList
			};

			var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
			{
				Content = new ObjectContent<error>(err, new JsonMediaTypeFormatter()),
				RequestMessage = _request
			};
			return Task.FromResult(response);
		}
	}

	public class Error
	{
		public string Code { get; set; }
		public string Message { get; set; }
	}

	public class error
	{
		public List<Error> errors { get; set; }
	}
}