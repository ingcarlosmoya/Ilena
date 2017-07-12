import { Component, OnInit } from '@angular/core';
import { Routine } from './../routine/routine';
import { Person } from './../people/person';
import { PhysicalExam } from './../people/physical-exam';
import { PersonBasicInfoComponent } from './../people/person-basic-info/person-basic-info.component'
import { PhysicalExamComponent } from './../people/physical-exam/physical-exam.component';
import { RoutineBasicResultComponent } from '../routine/routine-basic-result/routine-basic-result.component'

@Component({
  selector: 'app-evaluation',
  templateUrl: './evaluation.component.html',
  styleUrls: ['./evaluation.component.css']
})
export class EvaluationComponent implements OnInit {

 routines:Routine[];
 person:Person;
 physicalExam: PhysicalExam;
 routine:Routine;

  
  constructor() { }

  ngOnInit() {
    this.person = new Person();
    this.person.name = 'Tom';
    this.person.lastName = 'Brady';
    this.person.age = 32;
    this.person.gender = "Male";

    this.physicalExam = new PhysicalExam();
    this.physicalExam.weight = 63.5;
    this.physicalExam.height = 1.70;
    this.physicalExam.bmi = 20.56;
    this.physicalExam.bmiDiagnostic = 'Very severely underweight';
    
    this.routines = new Array();
    this.routine = new Routine();
    this.routine.name = "Routine 1";
    this.routine.evaluation = "success";
    this.routine.result = 170;
    this.routine.sort = 1;
    this.routines.push(this.routine)
    this.routine = new Routine();
    this.routine.name = "Routine 2";
    this.routine.evaluation = "warning";
    this.routine.result = 190;
    this.routine.sort = 2;
    this.routines.push(this.routine)
    this.routine = new Routine();
    this.routine.name = "Routine 1";
    this.routine.evaluation = "danger";
    this.routine.result = 160;
    this.routine.sort = 3;
    this.routines.push(this.routine)
  }

}
