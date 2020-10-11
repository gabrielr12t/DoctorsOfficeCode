import { Patient } from './patient.model';

export class MedicalAppointment {
    startDate: Date;
    finalDate: Date;
    comments: string;
    patient: Patient;
    patientId: number;
}