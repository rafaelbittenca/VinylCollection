using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic;
using System.Net;
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

		public JsonResult Listar(ParametrosPaginacao parametrosPaginacao)
		{
			DadosFiltrados dadosFiltrados = FiltrarEPaginar(parametrosPaginacao);

			return Json(dadosFiltrados, JsonRequestBehavior.AllowGet);
		}

		private DadosFiltrados FiltrarEPaginar(ParametrosPaginacao parametrosPaginacao)
		{

			var artists = _unitOfWork.Artists.GetAll();

			int total = artists.Count();

			if (!String.IsNullOrWhiteSpace(parametrosPaginacao.SearchPhrase))
			{
				// Dynamic LINQ 
				artists = artists.Where("Name.ToLower().Contains(@0) ", parametrosPaginacao.SearchPhrase.ToLower());
			}

			var artistsFiltered = artists.OrderBy(parametrosPaginacao.CampoOrdenado)
							     .Skip((parametrosPaginacao.Current - 1) * parametrosPaginacao.RowCount)
							     .Take(parametrosPaginacao.RowCount).ToList();

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
		public ActionResult Create()
		{
			return PartialView();
		}

		// POST: Artist/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
		#endregion

		#region Detail
		public ActionResult Details(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var artist = _unitOfWork.Artists.GetById(id);
			var artistView = Mapper.Map<Artist, ArtistViewModel>(artist);

			if (artist == null)
			{
				return HttpNotFound();
			}

			return PartialView(artistView);
		}
		#endregion

		#region Edit
		// GET: Artist/Edit
		public ActionResult Edit(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var artist = _unitOfWork.Artists.GetById(id);
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
		[HttpPost]
		[ValidateAntiForgeryToken]
		public JsonResult Edit([Bind(Include = "Id,Name,BirthDate,AboutLink")] ArtistViewModel artistView)
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
		public ActionResult Delete(int? id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var artist = _unitOfWork.Artists.GetById(id);
			var artistView = Mapper.Map<Artist, ArtistViewModel>(artist);
			if (artist == null)
			{
				return HttpNotFound();
			}
			return PartialView(artistView);
		}

		// POST: Livros/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public JsonResult DeleteConfirmed(int id)
		{
			try
			{
				Artist artist = _unitOfWork.Artists.Get(id);
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