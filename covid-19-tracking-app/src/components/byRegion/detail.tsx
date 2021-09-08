import React, { useRef, useState } from 'react';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import "./regionItem.css";
import { Translation } from '../translation';
import { Line } from "react-chartjs-2";
import { RegionColors } from '../../types/colors';
import { dictionaryList, localeOptions } from '../../locales';
import { useAppContext } from '../../contexts/appContext';
import { useGetDetailByRegionQuery } from '../../services/getDetailByRegion';
import DetailLoading from './detailLoading';
import { CovidReportDetailRequest } from '../../types/covidReportDetailRequest';
import { uuid } from 'uuidv4';
import * as bt from 'react-bootstrap';
import ListCountriesByRegion from '../listCountriesByRegion';

type Props = {
    selectedItemData: Covid19DataByRegion;
}

const RegionDetail: React.FC<Props> = ({ selectedItemData }) => {
    const { locale, } = useAppContext();

    let start = new Date();
    start.setDate(new Date().getDate() - 7)
    const defaultPayload = {
        regionCode: selectedItemData.regionCode,
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
            regionCode: selectedItemData.regionCode,
            startDate: start,
            endDate: new Date(),
        };
        setPayload(payload);
    };

    const [payload, setPayload] = useState<CovidReportDetailRequest>(defaultPayload);
    const { data, error, isFetching, isLoading } = useGetDetailByRegionQuery({ payload: payload });

    return (
        <>
            {selectedItemData && (
                <bt.Container>
                    <bt.Row>
                        <bt.Col md={8} >
                            <h3 className="mt-3 " style={{ color: RegionColors[selectedItemData?.regionCode] }}  >
                                <b><Translation tid={selectedItemData?.regionCode} />&nbsp;<Translation tid="detail" /></b>
                            </h3>
                        </bt.Col>
                        <bt.Col md={4} >
                            <div className="mt-4 text-right"  >
                                <b><span className="text-warning">
                                    {selectedItemData.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })} </span>
                                    /
                                    <span className="text-danger"> {selectedItemData.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</span>&nbsp;
                                    (<span>{((selectedItemData.deaths / selectedItemData.confirmed) * 100).toFixed(2)} %</span>)
                                </b>
                            </div>
                        </bt.Col>
                    </bt.Row>
                    <hr />
                    <bt.Row>
                        <bt.Col md={4} >
                            <ListCountriesByRegion region={selectedItemData} />
                        </bt.Col>

                        <bt.Col md={8} >
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

                                        <div>
                                            <div className="mt-3">
                                                <b><Translation tid="PersonFullyVaccinated" />: &nbsp;
                                                    {

                                                        data?.resource.vaccineReport.personFullyVaccinated.toLocaleString(undefined, { maximumFractionDigits: 0 })

                                                    }
                                                </b>
                                            </div>
                                            <div className="mt-2">
                                                <b><Translation tid="PersonVaccinated1PlusDose" />: &nbsp;
                                                    {

                                                        data?.resource.vaccineReport.personVaccinated1PlusDose.toLocaleString(undefined, { maximumFractionDigits: 0 })

                                                    }
                                                </b>
                                            </div>
                                            <div className="mt-2">
                                                <b><Translation tid="vaccinesUsed" /></b>: &nbsp;
                                                {
                                                    data?.resource.vaccineReport.vaccinesUsed
                                                }
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

export default RegionDetail;