import { Routes, RouterModule } from '@angular/router';
import { EvaluationComponent } from "./evaluation/evaluation.component";
import { SearchComponent } from "./search/search.component";

// Route config let's you map routes to components
const routes: Routes = [
  // map '/persons' to the people list component
  {
    path: 'evaluation/:id',
    component: EvaluationComponent,
  },
   {
    path: 'search',
    component: SearchComponent,
  },
  // map '/' to '/persons' as our default route
  {
    path: '',
    redirectTo: '/search',
    pathMatch: 'full'
  },
];

export const appRouterModule = RouterModule.forRoot(routes);