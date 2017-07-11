import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {NgbModule} from '@ng-bootstrap/ng-bootstrap';

import { AppComponent } from './app.component';
import { RoutineBasicResultComponent } from './routine/routine-basic-result/routine-basic-result.component';
import { EvaluationComponent } from './evaluation/evaluation.component';
import { PersonBasicInfoComponent } from './people/person-basic-info/person-basic-info.component';

@NgModule({
  declarations: [
    AppComponent,
    RoutineBasicResultComponent,
    EvaluationComponent,
    PersonBasicInfoComponent
  ],
  imports: [
    BrowserModule,
    NgbModule.forRoot()
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
