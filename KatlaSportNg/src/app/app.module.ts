import { HttpClient, HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { AppRoutingModule } from 'app/app-routing.module';
import { AppComponent } from 'app/app.component';
import { HiveFormComponent } from 'app/hive-management/forms/hive-form.component';
import { HiveSectionFormComponent } from 'app/hive-management/forms/hive-section-form.component';
import { HiveListComponent } from 'app/hive-management/lists/hive-list.component';
import { HiveSectionListComponent } from 'app/hive-management/lists/hive-section-list.component';
import { HiveSectionService } from 'app/hive-management/services/hive-section.service';
import { HiveService } from 'app/hive-management/services/hive.service';
import { MainPageComponent } from 'app/main-page/main-page.component';
import { ProductCategoryFormComponent } from 'app/product-management/forms/product-category-form.component';
import { ProductFormComponent } from 'app/product-management/forms/product-form.component';
import { ProductCategoryListComponent } from 'app/product-management/lists/product-category-list.component';
import { ProductCategoryProductListComponent } from 'app/product-management/lists/product-category-product-list.component';
import { ProductListComponent } from 'app/product-management/lists/product-list.component';
import { ProductCategoryService } from 'app/product-management/services/product-category.service';
import { ProductService } from 'app/product-management/services/product.service';
import { UserComponent } from './login-managment/forms/user/user.component';
import { SignInComponent } from './login-managment/forms/user/sign-in/sign-in.component';
import { SignUpComponent } from './login-managment/forms/user/sign-up/sign-up.component';
import { UserService} from './login-managment/services/login.service'
import { ToastrModule } from 'ngx-toastr';
import { AuthGuard } from './login-managment/auth/auth.guard';
import { AuthInterceptor} from './login-managment/auth/auth.interceptor';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HeaderComponent } from './header/header.component';

@NgModule({
  declarations: [
    AppComponent,
    MainPageComponent,
    ProductCategoryListComponent,
    ProductCategoryFormComponent,
    ProductCategoryProductListComponent,
    ProductListComponent,
    ProductFormComponent,
    HiveListComponent,
    HiveFormComponent,
    HiveSectionFormComponent,
    HiveSectionListComponent,
    UserComponent,
    SignInComponent,
    SignUpComponent,
    HeaderComponent,
  ],
  imports: [
    // Angular imports
    BrowserModule,
    FormsModule,
    NgbModule.forRoot(),
    HttpClientModule,
    // Application imports
    AppRoutingModule,
    ToastrModule.forRoot(),
    BrowserAnimationsModule
  ],
  providers: [
    // Angular providers
    HttpClient,
    // Application providers
    ProductService,
    ProductCategoryService,
    HiveService,
    HiveSectionService,
    UserService,
    AuthGuard,
    {
      provide : HTTP_INTERCEPTORS,
      useClass : AuthInterceptor,
      multi : true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
