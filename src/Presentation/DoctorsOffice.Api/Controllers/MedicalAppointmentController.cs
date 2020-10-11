using DoctorsOffice.Api.V1.Requests;
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
        public async Task<Response<List<MedicalAppointment>>> MedicalAppointmentGet([FromQuery] bool? fromTodayDate, bool? fromPreviousDate)
        {
            Response<List<MedicalAppointment>> response = new Response<List<MedicalAppointment>>();

            try
            {
                response.Data = await _medicalAppointmentService.SelectAsync(fromTodayDate: fromTodayDate, fromPreviousDate: fromPreviousDate);
            }
            catch (Exception ex)
            {
                response.Errors = new List<string> { ex.Message };
            }

            return response;
        }

        [Route("medical-appointment")]
        [HttpPost]
        public async Task<Response<MedicalAppointment>> MedicalAppointmentCreate([FromBody] MedicalAppointmentRequest request)
        {
            Response<MedicalAppointment> response = new Response<MedicalAppointment>();

            try
            {
                await _medicalAppointmentService.AddAsync(request.ToModel());
            }
            catch (Exception ex)
            {
                response.Errors = new List<string> { ex.Message };
            }

            return response;
        }
    }
}
