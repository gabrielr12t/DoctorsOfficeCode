import { Component, OnInit } from '@angular/core';
import { MedicalAppointment } from 'src/app/shared/model/medicalAppointment.model';
import { MedicalAppointmentService } from 'src/app/shared/service/medical-appointment.service';

@Component({
  selector: 'app-medical-appointments-list',
  templateUrl: './medical-appointments-list.component.html',
  styleUrls: ['./medical-appointments-list.component.css']
})
export class MedicalAppointmentsListComponent implements OnInit {

  medicalAppointmentPrevious: MedicalAppointment[];
  medicalAppointmentNext: MedicalAppointment[];
  next: boolean = false;
  previous: boolean = false;

  constructor(
    public medicalAppointmentServicee: MedicalAppointmentService
  ) { }

  ngOnInit(): void {
    this.getMedicalAppointments();
  }

  getMedicalAppointments() {
    this.medicalAppointmentServicee.getMedicalAppointmentsPreviousDate().subscribe(data => {
      this.medicalAppointmentPrevious = data.data;
      this.previous = true;
    });

    this.medicalAppointmentServicee.getMedicalAppointmentsFromDate().subscribe(data => {
      this.medicalAppointmentNext = data.data;
      this.next = true;
    });
  }
}
