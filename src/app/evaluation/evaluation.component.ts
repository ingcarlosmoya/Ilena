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

  
  constructor() { }

  ngOnInit() {
     this.routines = new Array();
  }

}
