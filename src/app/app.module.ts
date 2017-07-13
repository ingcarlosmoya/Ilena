import { BrowserModule } from '@angular/platform-browser';
//import { BrowserAnimationsModule } from '@angular/platform-browser-animations';
import { NgModule } from '@angular/core';
import { NgbModule} from '@ng-bootstrap/ng-bootstrap';
import { NgxChartsModule } from '@swimlane/ngx-charts';

import { AppComponent } from './app.component';
import { RoutineBasicResultComponent } from './routine/routine-basic-result/routine-basic-result.component';
import { EvaluationComponent } from './evaluation/evaluation.component';
import { PersonBasicInfoComponent } from './people/person-basic-info/person-basic-info.component';
import { PhysicalExamComponent } from './people/physical-exam/physical-exam.component';

@NgModule({
  declarations: [
    AppComponent,
    RoutineBasicResultComponent,
    EvaluationComponent,
    PersonBasicInfoComponent,
    PhysicalExamComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot(),
    NgxChartsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
