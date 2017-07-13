import { Component, Input, OnInit } from '@angular/core';
import { PhysicalExam } from './../physical-exam';
@Component({
  selector: 'app-physical-exam',
  templateUrl: './physical-exam.component.html',
  styleUrls: ['./physical-exam.component.css']
})
export class PhysicalExamComponent implements OnInit {

  @Input() physicalExam: PhysicalExam;
  bmiClass: string;

  view: any[] = [200, 100];
  data: any[];


  constructor() {

    var single = [
      {
        "name": "Germany",
        "value": 8940000
      },
      {
        "name": "USA",
        "value": 5000000
      },
      {
        "name": "France",
        "value": 7200000
      }];

    this.data = single;
  }


  colorScheme = {
    domain: ['#5AA454', '#A10A28', '#C7B42C']
  };

  onSelect(event) {
    console.log(event);
  }
  ngOnInit() {
  }

  getBmiDiagnosticClass(): string {

    var className: string;
    var bmi: number = this.physicalExam.bmi;

    if (this.physicalExam.bmi < 18.50) {
      this.bmiClass = 'alert-info';
    }
    else if (bmi >= 18.50 && bmi < 25) {
      this.bmiClass = 'alert-success';
    }
    else if (bmi >= 25 && bmi < 30) {
      this.bmiClass = 'alert-warning';
    }
    else if (bmi >= 30) {
      this.bmiClass = 'alert-danger';
    }

    className = 'form-control  alert ' + this.bmiClass;

    return className;
  }

}