using DoctorsOffice.Api.V1.Responses;
using DoctorsOffice.Core.Models;
using DoctorsOffice.Services.MedicalAppointments;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DoctorsOffice.Api.Controllers
{
    [ApiController]
    // [Route("api/medicalAppointment")]
    [Route("api/[controller]")]
    public class MedicalAppointmentController : ControllerBase
    {
        private readonly IMedicalAppointmentService _medicalAppointmentService;

        public MedicalAppointmentController(IMedicalAppointmentService medicalAppointmentService)
        {
            _medicalAppointmentService = medicalAppointmentService;
        }

        [Route("medical-appointments")]
        [HttpGet]
        public async Task<Response<List<MedicalAppointment>>> MedicalAppointmentGet()
        {
            Response<List<MedicalAppointment>> response = new Response<List<MedicalAppointment>>();

            try
            {
                response.Data = await _medicalAppointmentService.SelectAsync();
            }
            catch (Exception ex)
            {
                response.Errors = new List<string> { ex.Message };
            }

            return response;
        }

        [Route("medical-appointment")]
        [HttpPost]
        public async Task<Response<MedicalAppointment>> MedicalAppointmentCreate([FromQuery] MedicalAppointment medicalAppointment)
        {
            Response<MedicalAppointment> response = new Response<MedicalAppointment>();

            try
            {
                await _medicalAppointmentService.AddAsync(medicalAppointment);
            }
            catch (Exception ex)
            {
                response.Errors = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
