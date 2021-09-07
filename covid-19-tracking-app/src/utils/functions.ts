import axios from "axios";
import { useGetCurrentCountryQuery } from "../services/getCurrentCountry";
import { AppSetting } from "../types/type";

const bgColors = ["primary", "secondary", "success", "danger", "warning", "info", "dark"];
export function GetRandomBgColor() {
    return bgColors[Math.floor(Math.random() * bgColors.length)];;
}

let appSetting: AppSetting = require('../appSetting.json');


export async function GetCurrentCountry() {
    try {
        await axios.get(appSetting.CountryViaIPUrl).then((res) => {
            console.log(res.data.countryCode)
            return res.data.countryCode;
        });
    } catch (error) {
        return "VN";
    }
}