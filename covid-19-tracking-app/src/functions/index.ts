import axios from 'axios';

export const GetCurrentCountry = () => {
    // let countryCode = "vn";
    // let countryName = "Việt Nam";

    // if (navigator.geolocation) {
    //     navigator.geolocation.getCurrentPosition(function (position) {
    //         let lat = position.coords.latitude;
    //         let lon = position.coords.longitude;
    //         var url = `https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${lon}&key=${GoogleKey}`;
    //         console.log(url);
    //         axios
    //             .get(`https://maps.googleapis.com/maps/api/geocode/json?latlng=${lat},${lon}&key=${GoogleKey}`)
    //             .then((response) => {
    //                 let data = response.data;
    //                 console.log(data.country_name)
    //                 console.log(data.country_calling_code)
    //             })
    //             .catch(function (error) {
    //                 console.log(error);
    //             }); 
    //     });
    // }
    // return { countryCode, countryName }; 
}