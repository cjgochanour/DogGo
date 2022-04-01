using DogGo.Models;
using DogGo.Repositories;
using DogGo.Models.ViewModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace DogGo.Controllers
{
    public class WalkController : Controller
    {
        private readonly IWalkRepository _walkRepo;
        private readonly IWalkerRepository _walkerRepo;
        private readonly IDogRepository _dogRepo;
        public WalkController(IWalkRepository walkRepository, IWalkerRepository walkerRepository, IDogRepository dogRepository)
        {
            _walkRepo = walkRepository;
            _walkerRepo = walkerRepository;
            _dogRepo = dogRepository;
        }
        // GET: WalkController
        public ActionResult Index()
        {
            List<Walk> walks = _walkRepo.GetAllWalks();
            return View(walks);
        }

        // GET: WalkController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: WalkController/Create
        public ActionResult Create()
        {
            List<Walker> walkers = _walkerRepo.GetAllWalkers();
            List<Dog> dogs = _dogRepo.GetAllDogs();
            WalkFormViewModel wfvm = new WalkFormViewModel
            {
                Walkers = walkers,
                Dogs = dogs,
                Walk = new Walk(),
                DogIds = new List<int>()
            };
            return View(wfvm);
        }

        // POST: WalkController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(WalkFormViewModel wfvm)
        {
            try
            {
                foreach(int dogId in wfvm.DogIds)
                {
                    Walk walk = new Walk
                    {
                        Date = wfvm.Walk.Date,
                        Duration = wfvm.Walk.Duration,
                        WalkerId = wfvm.Walk.WalkerId,
                        DogId = dogId
                    };
                _walkRepo.AddWalk(walk);
                }

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        // GET: WalkController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: WalkController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: WalkController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: WalkController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
