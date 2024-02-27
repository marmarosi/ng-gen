/* 3rd party libraries */
import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';

/* globally accessible app code in every feature module */
import { SharedModule } from 'www/shared';

/* locally accessible feature module code, always use relative path */
import { routes } from './#dash-plural#.routes';
import { components } from './components';
import { dialogs } from './dialogs';
import { pages } from './pages';

@NgModule( {
  imports: [
    SharedModule,
    RouterModule.forChild( routes )
  ],
  declarations: [
    ...components,
    ...dialogs,
    ...pages
  ]
} )
export class #PascalPlural#Module { }