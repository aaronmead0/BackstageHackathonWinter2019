import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { FormControl} from '@angular/forms';
import { Text } from '@angular/compiler';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public results: string;
  public baseUrl: string;
  public http: HttpClient;
  equation1 = new FormControl('0');
  equation2 = new FormControl('1');

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.baseUrl = baseUrl;
    this.http = http;
  }


  getResults() {
    var a = this.equation1.value;
    var b = this.equation2.value;
    console.warn(this.baseUrl + 'api/Fabric/Calculator?a=' + a + '&b=' + b);
    this.http.get<string>(this.baseUrl + 'api/Fabric/Calculator?a=' + a + '&b=' + b, { responseType: 'text' }).subscribe(result => {
      this.results = result;
    }, error => console.error(error));
    console.warn(this.results);
  }
}




interface WeatherForecast {
  dateFormatted: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
