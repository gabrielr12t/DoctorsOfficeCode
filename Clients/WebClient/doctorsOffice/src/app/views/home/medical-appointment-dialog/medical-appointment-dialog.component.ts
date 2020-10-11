import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import * as moment from 'moment';
import { MedicalAppointmentService } from 'src/app/shared/service/medical-appointment.service';

@Component({
  selector: 'app-medical-appointment-dialog',
  templateUrl: './medical-appointment-dialog.component.html',
  styleUrls: ['./medical-appointment-dialog.component.css']
})
export class MedicalAppointmentDialogComponent implements OnInit {
  public medicalAppointmentForm: FormGroup;

  constructor(
    private fb: FormBuilder,
    private rest: MedicalAppointmentService,
    public dialogRef: MatDialogRef<MedicalAppointmentDialogComponent>
  ) { }

  ngOnInit(): void {

    this.medicalAppointmentForm = this.fb.group({
      startDate: ['', [Validators.required]],
      startTime: ['', [Validators.required]],
      finalDate: ['', [Validators.required]],
      finalTime: ['', [Validators.required]],
      comments: ['', [Validators.required]],
      patientName: ['', [Validators.required]],
      birthDate: ['', [Validators.required]]
    });
  }

  createMedicalAppointment() {
    let newStartDate: moment.Moment = moment.utc(this.medicalAppointmentForm.value.startDate).local();
    let newFinalDate: moment.Moment = moment.utc(this.medicalAppointmentForm.value.finalDate).local();

    this.medicalAppointmentForm.value.startDate = newStartDate.format("YYYY/MM/DD") + "T" + this.medicalAppointmentForm.value.startTime;
    this.medicalAppointmentForm.value.finalDate = newFinalDate.format("YYYY/MM/DD") + "T" + this.medicalAppointmentForm.value.finalTime;

    this.rest.postMedicalAppointment(this.medicalAppointmentForm.value).subscribe(result => { });
    this.dialogRef.close();
    this.medicalAppointmentForm.reset();
    window.location.reload();
  }

  cancel(): void {
    this.dialogRef.close();
    this.medicalAppointmentForm.reset();
  }
}
