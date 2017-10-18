using AutoMapper;
using System;
using System.Net;
using System.Web.Http;
using Vinyl.DAL.Contract;
using Vinyl.Models;
using Vinyl.UI.ViewModels;
using System.Linq;
using System.Collections.Generic;
using Vinyl.UI.Dtos;

namespace Vinyl.UI.Controllers.Api
{
	[RoutePrefix("api/artist")]
	//[Authorize]
	public class ArtistController : ApiController
	{
		private readonly IUnitOfWork _unitOfWork;

		public ArtistController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		[HttpGet]
		[Route("~/api/artist")]
		public IHttpActionResult LoadArtists()
		{
			var artists = _unitOfWork.Artists.GetAll().Select(Mapper.Map<Artist, ArtistDto>);
			return Ok(artists);
		}


		[HttpGet]
		[Route("{id:int}")]
		[Route("~/api/artist/{id}")]
		public IHttpActionResult LoadArtistById(int id)
		{
			var artist = _unitOfWork.Artists.GetById(id);
			if (artist != null)
			{
				return Ok(Mapper.Map<Artist,ArtistDto>(artist));
			}
			else
			{
				return Content(HttpStatusCode.NotFound, "Artist with Id " + id.ToString() + " not found");
			}
		}

		[HttpGet]
		[Route("{name:alpha}")]
		[Route("~/api/artist/{name}")]
		public IHttpActionResult LoadArtistsByName(string name)
		{
			var artists = _unitOfWork.Artists.Find(a => a.Name.ToLower().Contains(name.ToLower())).Select(Mapper.Map<Artist, ArtistDto>); 
			if (artists.ToList().Count() > 0)
			{
				return Ok(artists);
			}
			else
			{
				return Content(HttpStatusCode.NotFound, "Artist with Name " + name + " not found");
			}
		}

		[HttpPost]
		[Route("")]
		public IHttpActionResult CreateArtist([FromBody] ArtistDto artistDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest();
				var artist = Mapper.Map<ArtistDto, Artist>(artistDto);
				_unitOfWork.Artists.Add(artist);
				_unitOfWork.Complete();
				artistDto.Id = artist.ID;
				return Created(new Uri(Request.RequestUri + "/" + artistDto.Id), artistDto);
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.BadRequest, string.Format("Artist could not be saved: {0}",ex.Message));
			}
		}

		[HttpPut]
		[Route("{id:int}")]
		[Route("~/api/artist/{id}")]
		public IHttpActionResult UpdateArtist(int id, ArtistDto artistDto)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest();

				var artistInDb = _unitOfWork.Artists.GetById(id);
				if (artistInDb == null)
					return Content(HttpStatusCode.NotFound, string.Format("Artist with Id: {0} could not be found", id));

				Mapper.Map(artistDto, artistInDb);

				//Save
				_unitOfWork.Complete();

				return Ok();
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.BadRequest, string.Format("Artist could not be Updated: {0}", ex.Message));
			}
		}

		// DELETE /api/customers/1
		[HttpDelete]
		[Route("{id}")]
		public IHttpActionResult DeleteArtist(int id)
		{
			try
			{
				var artistInDb = _unitOfWork.Artists.GetById(id);

				if (artistInDb == null)
					return Content(HttpStatusCode.NotFound, string.Format("Artist with Id: {0} could not be found", id));

				var artist = Mapper.Map<Artist, ArtistDto>(artistInDb);

				_unitOfWork.Artists.Remove(artistInDb);
				_unitOfWork.Complete();

				return Ok();
			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.BadRequest, string.Format("Artist could not be Deleted: {0}", ex.Message));
			}
		}
	}
}
