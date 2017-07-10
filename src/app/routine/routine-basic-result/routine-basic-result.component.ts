import { Component, OnInit, Input } from '@angular/core';
import { Routine } from './../routine'

@Component({
  selector: 'app-routine-basic-result',
  templateUrl: './routine-basic-result.component.html',
  styleUrls: ['./routine-basic-result.component.css']
})
export class RoutineBasicResultComponent implements OnInit {

  @Input() routines:Routine[];
  
  constructor() { }

  ngOnInit() {
    
  }

}
