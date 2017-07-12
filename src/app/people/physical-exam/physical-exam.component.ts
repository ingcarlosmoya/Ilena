import { Component, Input, OnInit } from '@angular/core';
import { PhysicalExam } from './../physical-exam';
@Component({
  selector: 'app-physical-exam',
  templateUrl: './physical-exam.component.html',
  styleUrls: ['./physical-exam.component.css']
})
export class PhysicalExamComponent implements OnInit {

  @Input() physicalExam:PhysicalExam;
  bmiClass:string;

  constructor() { }

  ngOnInit() {
  }

  getBmiDiagnosticClass():string{
    
    var className:string;
    var bmi:number = this.physicalExam.bmi;
    
    if(this.physicalExam.bmi < 18.50)
    {
      this.bmiClass = 'alert-info';
    }
    else if (bmi >= 18.50 && bmi < 25){
         this.bmiClass = 'alert-success';
    }
    else if (bmi >= 25 && bmi < 30){
         this.bmiClass = 'alert-warning';
    }
    else if (bmi >= 30){
         this.bmiClass = 'alert-danger';
    }

    className = 'form-control  alert ' +  this.bmiClass;

    return className;
  }

}
