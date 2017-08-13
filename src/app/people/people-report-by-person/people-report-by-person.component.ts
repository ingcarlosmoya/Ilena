import { Component, OnInit, Input } from '@angular/core';
import { ChartsModule } from 'ng2-charts/ng2-charts';
import { Routine } from './../../routine/routine';

@Component({
  selector: 'app-people-report-by-person',
  templateUrl: './people-report-by-person.component.html',
  styleUrls: ['./people-report-by-person.component.css']
})
export class PeopleReportByPersonComponent implements OnInit {

  @Input() routine:Routine;
  constructor() { }

  ngOnInit() {
    this.setSerie();
  }


  setSerie(){
  // this.lineChartData = [
  //   {data: [65.1, 64.2, 80, 65.1, 56, 55.5, 40], label: 'Series A'}
  // ];

   this.lineChartLabels = ['January', 'February', 'March', 'April', 'May', 'June', 'July'];
  //this.lineChartLabels = ['0', '25', '50', '75', '100', '125', '150','175', '220']
  this.lineChartData = [{data: this.routine.angles, label: this.routine.name}];
  //console.log(this.routine.labels);
  this.lineChartLabels = this.routine.labels;
  }
  // lineChart
  public lineChartData:Array<any>;
  public lineChartLabels:Array<any>;
  public lineChartOptions:any = {
    responsive: true
  };
  public lineChartColors:Array<any> = [
    { // grey
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    },
    { // dark grey
      backgroundColor: 'rgba(77,83,96,0.2)',
      borderColor: 'rgba(77,83,96,1)',
      pointBackgroundColor: 'rgba(77,83,96,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(77,83,96,1)'
    },
    { // grey
      backgroundColor: 'rgba(148,159,177,0.2)',
      borderColor: 'rgba(148,159,177,1)',
      pointBackgroundColor: 'rgba(148,159,177,1)',
      pointBorderColor: '#fff',
      pointHoverBackgroundColor: '#fff',
      pointHoverBorderColor: 'rgba(148,159,177,0.8)'
    }
  ];
  public lineChartLegend:boolean = true;
  public lineChartType:string = 'line';
 
  public randomize():void {
    let _lineChartData:Array<any> = new Array(this.lineChartData.length);
    for (let i = 0; i < this.lineChartData.length; i++) {
      _lineChartData[i] = {data: new Array(this.lineChartData[i].data.length), label: this.lineChartData[i].label};
      for (let j = 0; j < this.lineChartData[i].data.length; j++) {
        _lineChartData[i].data[j] = Math.floor((Math.random() * 100) + 1);
      }
    }
    this.lineChartData = _lineChartData;
  }
 
  // events
  public chartClicked(e:any):void {
    console.log(e);
  }
 
  public chartHovered(e:any):void {
    console.log(e);
  }

}
