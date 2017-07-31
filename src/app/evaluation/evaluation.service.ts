import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Evaluation } from './evaluation';
import { Person } from './../people/person';
import { PhysicalExam } from './../people/physical-exam';

import { Http, Response, Headers, RequestOptions } from '@angular/http';

@Injectable()
export class EvaluationService {

  private baseUrl: string = 'http://localhost:55002/api'

  constructor(private http: Http) { }

  getEvaluationByPatientId(id: string): Observable<Evaluation> {
    let evaluation$ = this.http
      .get(`${this.baseUrl}/evaluation/${id}`, { headers: this.getHeaders() })
      .map(mapEvaluation); 
    return null;
  }

  private getHeaders() {

    let headers = new Headers();
    headers.append('Accept', 'application/json');
    return headers;
  }

}


function mapEvaluation(response: Response): Evaluation {
  return response.json().map(toEvaluation)
}

function toEvaluation(r: any): Evaluation {
  let city = <Evaluation>(
    {
      person: toPerson(r.patient),
      physicalExam: toPhysicalExam(r.patient)
    });
  return city;
}

function toPerson(p: any): Person {
  let person = <Person>(
    {
      name: p.name,
      lastName: p.lastname,
      gender: p.gender,
      age: p.age
    });
  return person;
}

function toPhysicalExam(p: any): PhysicalExam {
  let physicalExam = <PhysicalExam>(
    {
      height: p.height,
      weight: p.weight,
      bmi: p.bmi,
      bmiDiagnostic: p.bmiDiagnostic,
      bmiClass: p.bmiClass
    });
  return physicalExam;
}
