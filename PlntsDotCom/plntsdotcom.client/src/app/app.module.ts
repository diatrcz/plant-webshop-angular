import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './components/app.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { HeaderComponent } from './components/header/header.component';
import { ProductListItemComponent } from './components/product-list-item/product-list-item.component';
import { ProductDetailsComponent } from './components/product-details/product-details.component';
import { MainPageComponent } from './components/main-page/main-page.component';
import { PlantsListComponent } from './components/plants-list/plants-list.component';
import { FilterComponent } from './components/filter/filter.component';
import { SearchListComponent } from './components/search-list/search-list.component';

@NgModule({
  declarations: [
    AppComponent,
    NavbarComponent,
    HeaderComponent,
    ProductListItemComponent,
    ProductDetailsComponent,
    MainPageComponent,
    PlantsListComponent,
    FilterComponent,
    SearchListComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
