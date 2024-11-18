import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSnackBarModule } from '@angular/material/snack-bar';
//import { ToastrModule } from 'ngx-toastr';

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
import { ShoppingCartComponent } from './components/shopping-cart/shopping-cart.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent } from './components/register/register.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { NotificationComponent } from './components/notification/notification.component';
import { AuthInterceptor } from './auth.interceptor';
import { AddProductComponent } from './components/add-product/add-product.component';
import { provideAnimationsAsync } from '@angular/platform-browser/animations/async';
import { OrderDetailsComponent } from './components/order-details/order-details.component';
import { OrdersComponent } from './components/orders/orders.component';
import { SidenavComponent } from './components/sidenav/sidenav.component';
import { WishlistComponent } from './components/wishlist/wishlist.component';


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
    ShoppingCartComponent,
    LoginComponent,
    RegisterComponent,
    UserProfileComponent,
    NotificationComponent,
    AddProductComponent,
    OrderDetailsComponent,
    OrdersComponent,
    SidenavComponent,
    WishlistComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    AppRoutingModule,
    ReactiveFormsModule,
    //ToastrModule.forRoot(),
    BrowserAnimationsModule,
    MatSnackBarModule
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: AuthInterceptor, multi: true},
    provideAnimationsAsync()
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
