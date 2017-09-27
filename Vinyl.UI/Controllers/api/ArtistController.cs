﻿using AutoMapper;
using System;
using System.Net;
using System.Web.Http;
using Vinyl.DAL.Contract;
using Vinyl.Models;
using Vinyl.UI.ViewModels;
using System.Linq;
using System.Collections.Generic;

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
		//[Route("")]
		[Route("~/api/artist")]
		public IHttpActionResult LoadArtists()
		{
			var artists = _unitOfWork.Artists.GetAll();
			return Ok(artists);
		}


		[HttpGet]
		// "{id:int:min(1)} - Route Constraints
		// Name ="GetArtistById" - Use Links routes
		[Route("{id:int)}", Name = "GetArtistById")]
		//Override RoutePrefix
		[Route("~/api/artist/{id}")]
		public IHttpActionResult LoadArtistById(int id)
		{
			var artist = _unitOfWork.Artists.GetById(id);
			if (artist != null)
			{
				return Ok(artist);
			}
			else
			{
				return Content(HttpStatusCode.NotFound, "Artist with Id " + id.ToString() + " not found");
			}
		}

		[HttpGet]
		//Route Constraints
		[Route("{name:alpha}")]
		[Route("~/api/artist/{name}")]
		public IHttpActionResult LoadArtistsByName(string name)
		{
			var artists = _unitOfWork.Artists.Find(a => a.Name.ToLower().Contains(name.ToLower()));
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
		public IHttpActionResult CreateArtist([FromBody] Artist artist)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest();
				_unitOfWork.Artists.Add(artist);
				_unitOfWork.Complete();
				return Created(new Uri(Request.RequestUri + "/" + artist.ID), artist);

			}
			catch (Exception ex)
			{
				return Content(HttpStatusCode.BadRequest, string.Format("Artist could not be saved: {0}",ex.Message));
			}
		}


		// PUT /api/customers/1
		[HttpPut]
		[Route("{id}")]
		public IHttpActionResult UpdateArtist(int id, ArtistViewModel artistView)
		{
			try
			{
				if (!ModelState.IsValid)
					return BadRequest();

				var artistInDb = _unitOfWork.Artists.GetById(id);
				if (artistInDb == null)
					return Content(HttpStatusCode.NotFound, string.Format("Artist with Id: {0} could not be found", id));

				//Mapper.Map(artistInDb, artistView);
				Mapper.Map<ArtistViewModel, Artist>(artistView);
				// Now we merge the view model properties into the model
				var artist = Mapper.Map(artistView, artistInDb);
				artist.ID = id;
				
				//Save
				_unitOfWork.Artists.Edit(artist);
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
