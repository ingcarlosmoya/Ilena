import { Component, OnInit } from '@angular/core';
import { Routine } from './../routine/routine';
import { Person } from './../people/person';
import { PhysicalExam } from './../people/physical-exam';
import { Habits } from './../people/habits';
import { PersonBasicInfoComponent } from './../people/person-basic-info/person-basic-info.component';
import { PhysicalExamComponent } from './../people/physical-exam/physical-exam.component';
import { RoutineBasicResultComponent } from '../routine/routine-basic-result/routine-basic-result.component';
import { HabitsComponent } from './../people/habits/habits.component';
import { EvaluationService } from './evaluation.service';
import { Evaluation } from './evaluation';
import { PeopleReportByPersonComponent } from './../people/people-report-by-person/people-report-by-person.component';

@Component({
  selector: 'app-evaluation',
  templateUrl: './evaluation.component.html',
  styleUrls: ['./evaluation.component.css']
})
export class EvaluationComponent implements OnInit {

  routines: Routine[];
  person: Person;
  physicalExam: PhysicalExam;
  habits: Habits;
  evaluation: Evaluation;
  


  constructor(private _evaluationService: EvaluationService) { }

  ngOnInit() {


 this.evaluation = new Evaluation();
    this._evaluationService.getEvaluationByPatientId('DC1B99C1-E3DF-41DC-B289-6E6FD7B968DD').subscribe(
      c => {
        this.evaluation = c;
        this.habits = this.evaluation.habits;
        this.routines = this.evaluation.routines;
        this.person = this.evaluation.person;
        this.physicalExam = this.evaluation.physicalExam;
      }
    );
    this.person = new Person();
    // this.person.name = 'Tom';
    // this.person.lastName = 'Brady';
    // this.person.age = 32;
    // this.person.gender = "male";

    this.physicalExam = new PhysicalExam();
    // this.physicalExam.weight = 63.5;
    // this.physicalExam.height = 170;
    // this.physicalExam.bmi = 14;
    // this.physicalExam.bmiDiagnostic = 'Very severely underweight';

    this.habits = new Habits();
    this.habits.activeBreaks = true;
    this.habits.seated = 10;
    this.habits.sleep = 8;
    this.habits.sport = true;

   

  }

}
