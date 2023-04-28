﻿using Blazored.Modal;
using Microsoft.AspNetCore.Components;

namespace Challenge.Valkimia.Presentation.Resources.Services
{
    public class ModalService : IModalService
    {
        private readonly Blazored.Modal.Services.IModalService _service;

        #region Constructor

        public ModalService(Blazored.Modal.Services.IModalService service)
        {
            _service = service;
        }

        #endregion

        #region Public Methods

        public IModalReference ShowModal<T>(string title) where T : IComponent
        {
            return _service.Show<T>(title);
        }

        public IModalReference ShowModal<T>(string title, ModalParameters parameters) where T : IComponent
        {
            return _service.Show<T>(title, parameters);
        }

        #endregion
    }
}
