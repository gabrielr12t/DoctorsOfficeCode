import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { MedicalAppointment } from '../model/medicalAppointment.model';
import { ResponseDoctorsOffice } from '../model/responseDoctorsOffice.model';

@Injectable({
  providedIn: 'root'
})
export class MedicalAppointmentService {

  apiUrl = 'https://localhost:5342/api/medicalAppointment';

  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  };

  constructor(
    private httpClient: HttpClient
  ) { }

  public getMedicalAppointmentsPreviousDate(): Observable<ResponseDoctorsOffice<MedicalAppointment>> {
    return this.httpClient.get<ResponseDoctorsOffice<MedicalAppointment>>(this.apiUrl + '/medical-appointments?fromPreviousDate=true');
  }

  public getMedicalAppointmentsFromDate(): Observable<ResponseDoctorsOffice<MedicalAppointment>> {
    return this.httpClient.get<ResponseDoctorsOffice<MedicalAppointment>>(this.apiUrl + '/medical-appointments?fromTodayDate=true');
  }

  public postMedicalAppointment(medicalAppointment: any):  Observable<ResponseDoctorsOffice<MedicalAppointment>> {
    return this.httpClient.post<any>(this.apiUrl + '/medical-appointment', medicalAppointment, this.httpOptions);
  }
}
