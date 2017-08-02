import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { Evaluation } from './evaluation';
import { Person } from './../people/person';
import { PhysicalExam } from './../people/physical-exam';
import { Habits } from './../people/habits';
import { Routine } from './../routine/routine';
import 'rxjs/add/operator/map'

import { Http, Response, Headers, RequestOptions } from '@angular/http';

@Injectable()
export class EvaluationService {

  private baseUrl: string = 'http://localhost:55002/api'

  constructor(private http: Http) { }

  getEvaluationByPatientId(id: string): Observable<Routine[]> {
    let evaluation$ = this.http
      .get(`${this.baseUrl}/evaluation/${id}`, { headers: this.getHeaders() })
      .map(mapEvaluation);
    return evaluation$;
  }



  private getHeaders() {

    let headers = new Headers();
    headers.append('Accept', 'application/json');
    headers.append('Access-Control-Allow-Origin', '*');
    headers.append('Access-Control-Allow-Methods','*');
    headers.append('Content-Type','application/json');

    return headers;
  }

}


function mapEvaluation(response: Response): Routine[] {
  console.log(response.json());
  return response.json().routines.map(toRoutine)
}


function toRoutine(p: any): Routine {
  let routine = <Routine>({
    name: p.name,
    result: p.result,
    evaluation: p.evaluation,
    pain: p.pain
  });
  return routine;
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
      height: p.physicalExam.height,
      weight: p.physicalExam.weight,
      bmi: p.physicalExam.bmi,
      bmiDiagnostic: p.physicalExam.bmiDiagnostic,
      bmiClass: p.physicalExam.bmiClass
    });
  return physicalExam;
}

function toHabits(p: any): Habits {
  let habits = <Habits>({
    activeBreaks: p.habits.activeBreaks,
    seated: p.habits.seated,
    sleep: p.habits.sleep,
    sport: p.habits.sport
  });
  return habits;
}
