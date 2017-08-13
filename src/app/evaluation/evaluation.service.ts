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

  getEvaluationByPatientId(id: string): Observable<Evaluation> {
      let evaluation$ =  this.http
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

function mapEvaluation(response: Response): Evaluation{
  var evaluation = new Evaluation();
  evaluation.habits = new Habits();
  evaluation.person = new Person();
  evaluation.physicalExam = new PhysicalExam();
  evaluation = toEvaluation(response.json());
   return evaluation;
}

function toEvaluation(p: any): Evaluation{
  let evaluation = <Evaluation>({
    person: toPerson(p.patient),
    habits: toHabits(p.patient.habits),
    physicalExam: toPhysicalExam(p.patient.physicalExam),
    routines: p.routines.map(toRoutine)
  });
  return evaluation;
}

function mapRoutine(response: Response): Routine[] {
  return response.json().routines.map(toRoutine)
}


function toRoutine(p: any): Routine {
  let routine = <Routine>({
    name: p.name,
    angle: p.angle,
    result: p.result,
    pain: p.pain,
    sort: p.name,
    label: p.name,
    angles: p.angles.map(toAngle),
    labels: p.labels.map(toLabel),
    mean: p.mean,
    median: p.median
  });
  return routine;
}

function toAngle(p: any): number {
  return p;
}

function toLabel(p: any): string {
  return p;
}

function mapPerson(response: Response): Person{
  return toPerson(response.json());
}

function toPerson(p: any): Person {
  let person = <Person>(
    {
      name: p.name,
      lastName: p.lastName,
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

function toHabits(p: any): Habits {
  let habits = <Habits>({
    activeBreaks: p.activeBreaks,
    seated: p.seated,
    sleep: p.sleep,
    sport: p.sport
  });
  return habits;
}
