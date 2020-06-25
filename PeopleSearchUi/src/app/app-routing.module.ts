import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PeopleSearchComponent } from './people-search/people-search.component';
import { PeopleAddComponent } from './people-add/people-add.component';
import { PageNotFoundComponent } from './page-not-found/page-not-found.component';

const routes: Routes = [
  {
    path: '',
    component: PeopleSearchComponent
  },
  {
    path: 'people-search',
    component: PeopleSearchComponent
  },
  {
    path: 'people-add',
    component: PeopleAddComponent
  },
  {
    path: '**',
    component: PageNotFoundComponent
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
