﻿using Microsoft.AspNetCore.Mvc;
using MyYTLoader.DAL.Entities;
using MyYTLoader.DAL.Repositories;
using MyYTLoader.Domain;

namespace MyYTLoader.Web.Controllers
{
    public class DownloadController: Controller
    {
        private readonly ILogsProvider _logsProvider;
        private readonly IDownloadService _downloadService;
        private readonly IVideoRepository _videoRepository;
        public DownloadController(ILogsProvider logsProvider, IDownloadService downloadService, IVideoRepository videoRepository)
        {
            this._logsProvider = logsProvider;
            this._downloadService = downloadService;
            _videoRepository = videoRepository;
        }

        // GET метод для отображения страницы
        public IActionResult Request(string video)
        {
            ViewData["Message"] = video;
            ViewBag.Test = video;
            return View();
        }
        
        // POST метод для обработки данных из формы
        [HttpPost]
        public IActionResult HandlePost(string name)
        {
            _logsProvider.AddLog(name);
            _downloadService.Download(name);
            // Логика обработки данных из формы
            // Например, сохраняем данные или выполняем валидацию

            /*if (string.IsNullOrEmpty(name))
            {
                // Если данные не заполнены, можно вернуть ошибку или запросить повторный ввод
                ModelState.AddModelError("", "Name and email are required.");
                return View("MyForm");  // Вернемся к форме с ошибкой
            }*/

            // Если все в порядке, можно отправить подтверждение или redirect

            var video = _videoRepository.GetAll().FirstOrDefault();
            return View("Request", video);
        }
    }
}
