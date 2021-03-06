﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Vinyl.DAL.Contract;
using Vinyl.Models;
using Vinyl.UI.Infra;
using Vinyl.UI.ViewModels;

namespace Vinyl.UI.Controllers
{

	public class ArtistController : Controller
	{
		private readonly IUnitOfWork _unitOfWork;

		public ArtistController(IUnitOfWork unitOfWork)
		{
			_unitOfWork = unitOfWork;
		}

		#region List

		// GET: Artist
		public ActionResult Index()
		{
			ViewBag.ReadOnly = "YES";
			return View();
		}
		// GET: Artist FullActions
		[Authorize]
		public ActionResult FullAccess()
		{
			ViewBag.ReadOnly = "NO";
			return View("Index");
		}

		public async Task<JsonResult> Listar(ParametrosPaginacao parametrosPaginacao)
		{
			DadosFiltrados dadosFiltrados = await FiltrarEPaginar(parametrosPaginacao);

			return Json(dadosFiltrados, JsonRequestBehavior.AllowGet);
		}

		private async Task<DadosFiltrados> FiltrarEPaginar(ParametrosPaginacao parametrosPaginacao)
		{

			var artists = await _unitOfWork.Artists.GetAllAsync();

			int total = artists.Count();

			if (!String.IsNullOrWhiteSpace(parametrosPaginacao.SearchPhrase))
			{
				// Dynamic LINQ 
				artists = artists.Where("Name.ToLower().Contains(@0) ", parametrosPaginacao.SearchPhrase.ToLower());
			}

			var artistsFiltered = artists.OrderBy(parametrosPaginacao.CampoOrdenado)
							     .Skip((parametrosPaginacao.Current - 1) *								  parametrosPaginacao.RowCount)
							     .Take(parametrosPaginacao.RowCount)
							     .ToList();

			DadosFiltrados dadosFiltrados = new DadosFiltrados(parametrosPaginacao)
			{
				rows = artistsFiltered.ToList(),
				total = total
			};
			return dadosFiltrados;
		}
		#endregion

		#region Create
		// GET: Artist/Create
		[Authorize]
		public ActionResult Create()
		{
			return PartialView();
		}

		// POST: Artist/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult Create([Bind(Include = "Id,Name,BirthDate,AboutLink")] ArtistViewModel artist)
		{
			if (ModelState.IsValid)
			{
				var artistView = Mapper.Map<ArtistViewModel, Artist>(artist);
				_unitOfWork.Artists.Add(artistView);
				_unitOfWork.Complete();
				return Json(new { resultado = true, message = "Artist successfully registered!" });
			}
			else
			{
				IEnumerable<ModelError> erros = ModelState.Values.SelectMany(item => item.Errors);

				return Json(new { resultado = false, message = erros });
			}
		}



		// GET: Artist/Save
		[Authorize]
		public ActionResult Save()
		{
			return View();
		}

		// POST: Artist/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Save(ArtistViewModel artist, HttpPostedFileBase upload)
		{
			if (ModelState.IsValid)
			{
				// Read the image data into a byte array
				if (upload != null)
				{
					var imageContent = new byte[upload.ContentLength];
					upload.InputStream.Read(imageContent, 0, imageContent.Length);
					artist.Picture = imageContent;
				}

				var artistView = Mapper.Map<ArtistViewModel, Artist>(artist);
				_unitOfWork.Artists.Add(artistView);
				_unitOfWork.Complete();
				//return Json(new { resultado = true, message = "Artist successfully registered!" });
				return RedirectToAction("FullAccess");
			}
			else
			{
				IEnumerable<ModelError> erros = ModelState.Values.SelectMany(item => item.Errors);

				//return Json(new { resultado = false, message = erros });
				return View(artist);
			}
		}
		#endregion

		#region Detail
		public async Task<ActionResult> Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var artist = await _unitOfWork.Artists.GetByIdAsync(id);
			var artistView = Mapper.Map<Artist, ArtistViewModel>(artist);

			if (artist == null)
			{
				return HttpNotFound();
			}

			return PartialView(artistView);
		}
		#endregion

		#region Edit
		[Authorize]
		// GET: Artist/Edit
		public async Task<ActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var artist = await _unitOfWork.Artists.GetByIdAsync(id);
			var artistView = Mapper.Map<Artist, ArtistViewModel>(artist);

			if (artist == null)
			{
				return HttpNotFound();
			}
			return PartialView(artistView);
		}

		// POST: Livros/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[Authorize]
		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult Edit(ArtistViewModel artistView)
		{

			if (!ModelState.IsValid)
			{
				//Return Error Validation to ajax request
				return Json(new { resultado = false, message = ModelState.Errors() }, JsonRequestBehavior.AllowGet);
			}

			var artist = Mapper.Map<ArtistViewModel, Artist>(artistView);
			_unitOfWork.Artists.Edit(artist);
			_unitOfWork.Complete();
			return Json(new { resultado = true, message = "Artist edited successfully!" });
		}

		#endregion

		#region Delete
		// GET: Artist/Delete
		[Authorize]
		public async Task<ActionResult> Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var artist = await _unitOfWork.Artists.GetByIdAsync(id);
			var artistView = Mapper.Map<Artist, ArtistViewModel>(artist);
			if (artist == null)
			{
				return HttpNotFound();
			}
			return PartialView(artistView);
		}

		// POST: Livros/Delete/5
		[Authorize]
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<JsonResult> DeleteConfirmed(int id)
		{
			try
			{
				Artist artist = await _unitOfWork.Artists.GetAsync(id);
				_unitOfWork.Artists.Remove(artist);
				_unitOfWork.Complete();
				return Json(new { resultado = true, message = "Successfully deleted artist!" });
			}
			catch (Exception ex)
			{
				return Json(new { resultado = false, message = ex.Message });
			}
		}
		#endregion

		// Simple test Json for PostMan
		//[Authorize]
		public JsonNetResult TestJsonPostmanReturn()
		{
			var dadosFiltrados = _unitOfWork.Artists.GetAll();

			return new JsonNetResult() { Data = dadosFiltrados };
		}

	}
}