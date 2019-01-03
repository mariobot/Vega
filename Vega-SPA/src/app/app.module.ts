import { FeatureService } from './services/feature.service';
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { AppRoutingModule } from './app-routing.module';
import { MakeService } from './services/Make.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';

@NgModule({
   declarations: [
      AppComponent,
      VehicleFormComponent
   ],
   imports: [
      FormsModule,
      BrowserModule,
      AppRoutingModule,
      HttpClientModule
   ],
   providers: [
      MakeService,
      FeatureService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
