import { Component, OnInit } from '@angular/core';
import { Routine } from './../routine'

@Component({
  selector: 'app-routine-basic-result',
  templateUrl: './routine-basic-result.component.html',
  styleUrls: ['./routine-basic-result.component.css']
})
export class RoutineBasicResultComponent implements OnInit {

  routines:Routine[];
  routine:Routine;
  
  constructor() { }

  ngOnInit() {
    this.routines = new Array();
    // this.routine = new Routine();
    // this.routine.name = "Routine 1";
    // this.routine.evaluation = "success";
    // this.routine.result = 170;
    // this.routines.push(this.routine)
  }

}
