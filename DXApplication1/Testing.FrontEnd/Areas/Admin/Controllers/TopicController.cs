﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DevExtreme.AspNet.Data;
using DevExtreme.AspNet.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Testing.DAL;
using Testing.Models;

namespace Testing.FrontEnd.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]

    [Route("Admin/Topic/{id}")]
    public class TopicController : Controller
    {
        private readonly TestingDbContext _db;
        public TopicController(TestingDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public object Get(DataSourceLoadOptions loadOptions)
        {
            return DataSourceLoader.Load(_db.Topics, loadOptions);
        }

        [Route("ListQuestions")]
        public IActionResult ListQuestions(Guid id) => View(_db.Topics.First(a => a.TopicId == id));

        [Route("Detail")]
        public IActionResult Index(Guid id)
        {
            var _topic = _db.Topics.First(t => t.TopicId == id);
            return View(_topic);
        }

        //public IActionResult yaIndex()
        //{
        //    var lstTopic = _db.Topics.ToList();
        //    return View(lstTopic);
        //}

        //public IActionResult Create()
        //{

        //    return View();
        //}

        //[HttpPost, ActionName("Create")]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> CreatePost(Topic _topic)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _db.Add(_topic);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(_topic);
        //}


        ////GET Edit Action  Method
        //public async Task<IActionResult> Edit(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var _topic = await _db.Topics.FindAsync(id);

        //    if (_topic == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(_topic);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        ////POST Edit Action  Method
        //public async Task<IActionResult> Edit(Guid id, Topic _topic)
        //{
        //    if (id != _topic.TopicId)
        //    {
        //        return NotFound();
        //    }
        //    if (ModelState.IsValid)
        //    {
        //        _db.Update(_topic);
        //        await _db.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(_topic);
        //}

        ////GET Delete Action  Method
        //public async Task<IActionResult> Delete(Guid? id)
        //{
        //    if (id == null)
        //    {
        //        return NotFound();
        //    }

        //    var _topic = await _db.Topics.FindAsync(id);

        //    if (_topic == null)
        //    {
        //        return NotFound();
        //    }

        //    return View(_topic);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]

        ////POST Delete Action  Method
        //public async Task<IActionResult> Delete(Guid id)
        //{
        //    var _topic = await _db.Topics.FindAsync(id);
        //    _db.Topics.Remove(_topic);

        //    await _db.SaveChangesAsync();
        //    return RedirectToAction(nameof(Index));
        //}

    }
}