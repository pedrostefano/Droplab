import { NgModule } from '@angular/core';

import {MdButtonModule, MdCheckboxModule, MdOptionModule, MdSelectModule} from '@angular/material';

@NgModule({
  imports: [MdButtonModule, MdOptionModule, MdSelectModule],
  exports: [MdButtonModule, MdOptionModule, MdSelectModule],
})
export class AngularMaterialModule {
  
 }