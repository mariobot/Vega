import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppComponent } from './app.component';
import { VehicleFormComponent } from './vehicle-form/vehicle-form.component';
import { AppRoutingModule } from './app-routing.module';
import { VehicleService } from './services/vehicle.service';
import { HttpClientModule } from '@angular/common/http';
import { FormsModule } from '@angular/forms';
import { VehicleListComponent } from './vehicle-list/vehicle-list.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';

@NgModule({
   declarations: [
      AppComponent,
      VehicleFormComponent,
      VehicleListComponent
   ],
   imports: [
      FormsModule,
      BrowserModule,
      AppRoutingModule,
      HttpClientModule,
      NgbModule
   ],
   providers: [
      VehicleService
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }
