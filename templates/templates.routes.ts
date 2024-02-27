/* 3rd party libraries */
import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

/* globally accessible app code in every feature module */

/* locally accessible feature module code, always use relative path */
import * as pages from './pages';

export const routes: Routes = [
  // {
  //   path: '',
  //   component: pages.ListPage
  // }, {
  //   path: ':key',
  //   component: pages.ViewPage
  // }, {
  //   path: ':key/edit',
  //   component: pages.EditPage
  // }
];