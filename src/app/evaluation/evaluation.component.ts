import { Component, OnInit } from '@angular/core';
import { Routine } from './../routine/routine';
import {RoutineBasicResultComponent} from '../routine/routine-basic-result/routine-basic-result.component'

@Component({
  selector: 'app-evaluation',
  templateUrl: './evaluation.component.html',
  styleUrls: ['./evaluation.component.css']
})
export class EvaluationComponent implements OnInit {

 routines:Routine[];
 routine:Routine;

  
  constructor() { }

  ngOnInit() {
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
