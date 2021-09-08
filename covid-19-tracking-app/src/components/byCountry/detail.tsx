import React, { useRef, useState } from 'react';
import { Translation } from '../translation';
import { Line } from "react-chartjs-2";
import { dictionaryList, localeOptions } from '../../locales';
import { useAppContext } from '../../contexts/appContext';
import { uuid } from 'uuidv4';
import * as bt from 'react-bootstrap';
import DetailLoading from '../byRegion/detailLoading';
import { useGetDetailByCountryQuery } from '../../services/getDetailByCountry';
import { Covid19DataByCountry, DetailByCountryRequest } from '../../types/covid19DataByCountry';
//@ts-ignore
import ReactCountryFlag from "react-country-flag";
import { KeyValues } from '../../locales/';
type Props = {
    selectedItemData: Covid19DataByCountry;
}

const CountryDetail: React.FC<Props> = ({ selectedItemData }) => {
    const { locale, } = useAppContext();

    let start = new Date();
    start.setDate(new Date().getDate() - 7)
    const defaultPayload = {
        countryCode: selectedItemData.countryCode,
        startDate: start,
        endDate: new Date(),
    };

    const selectedHandler = (type: string) => {
        let start = new Date();
        switch (type) {
            case "Weekly":
                start.setDate(new Date().getDate() - 7)
                break;
            case "Monthly":
                start.setMonth(new Date().getMonth() - 1)
                break;
            case "Yearly":
                start.setFullYear(new Date().getFullYear() - 1)
                break;
        }
        const payload = {
            countryCode: selectedItemData.countryCode,
            startDate: start,
            endDate: new Date(),
        };
        setPayload(payload);
    };

    const [payload, setPayload] = useState<DetailByCountryRequest>(defaultPayload);
    const { data, error, isFetching, isLoading } = useGetDetailByCountryQuery({ payload: payload });

    return (
        <>
            {selectedItemData && (
                <bt.Container>
                    <bt.Row>
                        <bt.Col md={12} >
                            <div className="d-flex justify-content-between p-3 my-3 text-white bg-info rounded shadow-sm" style={{ cursor: "pointer" }}
                            >
                                <div className="d-flex justify-content-between">
                                    <ReactCountryFlag className="emojiFlag"
                                        svg
                                        style={{
                                            width: '3em',
                                            height: '3em',
                                        }}
                                        title={KeyValues["country"][selectedItemData.countryCode]}
                                        countryCode={selectedItemData.countryCode} />&nbsp;


                                    <div className="lh-1  ml-3">
                                        <h1 className="h4 mb-0 text-white lh-1">{KeyValues["country"][selectedItemData.countryCode]}</h1>
                                    </div>
                                </div>

                                <div>
                                    <b><span className="text-warning">
                                        {selectedItemData.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })} </span>
                                        /
                                        <span className="text-danger"> {selectedItemData.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</span>&nbsp;
                                        (<span>{((selectedItemData.deaths / selectedItemData.confirmed) * 100).toFixed(2)} %</span>)
                                    </b>
                                    <div>
                                        &nbsp;
                                        <small style={{ fontSize: 12 }}>
                                            <Translation tid="Confirmed" /> / <Translation tid="Deaths" />
                                        </small >
                                    </div>
                                </div>
                            </div>
                        </bt.Col>

                    </bt.Row>
                    <hr />
                    <bt.Row>
                        <bt.Col md={12} >
                            <div className="position-relative">
                                <div className="float-right" style={{ width: 200 }}>
                                    <div className="btn-group btn-group-sm" role="group"  >
                                        <input type="radio" className="btn-check" name="btnradio" id="btnradio1" onClick={() => { selectedHandler('Weekly') }} />
                                        <label className="btn btn-outline-primary" htmlFor="btnradio1">Weekly</label>

                                        <input type="radio" className="btn-check" name="btnradio" id="btnradio2" onClick={() => { selectedHandler('Monthly') }} />
                                        <label className="btn btn-outline-primary" htmlFor="btnradio2">Monthly</label>

                                        <input type="radio" className="btn-check" name="btnradio" id="btnradio3" onClick={() => { selectedHandler('Yearly') }} />
                                        <label className="btn btn-outline-primary" htmlFor="btnradio3">Yearly</label>
                                    </div>
                                </div>
                            </div>
                            {(isFetching || isLoading) && <DetailLoading key={uuid()} lineCount={16} />}
                            {error && <div>{JSON.stringify(error)}</div>}
                            {!error && !isFetching && data?.success && data?.resource != null &&
                                <>

                                    <div className="position-relative">
                                        <div className="text-center" >
                                            <div style={{ width: "100%", height: 420 }}>
                                                <Line data={{
                                                    labels: data.resource.covidReportByDay.map((i) => new Date(i.reportDate).toLocaleDateString(locale)),
                                                    datasets: [
                                                        {
                                                            label: dictionaryList[locale]["Confirmed"],
                                                            data: data.resource.covidReportByDay.map((i) => i.totalConfirmed),
                                                            fill: false,
                                                            borderColor: "#f7c50c"
                                                        },
                                                        {
                                                            label: dictionaryList[locale]["Deaths"],
                                                            data: data.resource.covidReportByDay.map((i) => i.totalDeaths),
                                                            fill: false,
                                                            borderColor: "#f70c0c"
                                                        }
                                                    ]
                                                }} key={uuid()} />

                                            </div>
                                        </div>
                                    </div>
                                </>
                            }
                        </bt.Col>
                    </bt.Row>

                </bt.Container>
            )}

        </>
    )
}

export default CountryDetail;