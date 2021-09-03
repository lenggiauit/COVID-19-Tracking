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

    const [payload, setPayload] = useState<CovidReportDetailRequest>(defaultPayload);
    const { data, error, isFetching, isLoading } = useGetDetailByRegionQuery({ payload: payload });

    return (
        <>
            {selectedItemData && (
                <div className="mt-2">
                    <h5 style={{ color: RegionColors[selectedItemData?.regionCode] }}  >
                        <b><Translation tid={selectedItemData?.regionCode} />&nbsp;<Translation tid="detail" /></b>
                    </h5>
                    <hr />
                    {(isFetching || isLoading) && <DetailLoading key={uuid()} lineCount={16} />}
                    {error && <div>{JSON.stringify(error)}</div>}
                    {!error && !isFetching && data?.success &&
                        <>
                            <div className="d-flex justify-content-sm-center" >
                                <div style={{ width: "100%", height: 420 }}>
                                    <Line data={{
                                        labels: data.resource.covidReportByDayRegion.map((i) => new Date(i.reportDate).toLocaleDateString(locale)),
                                        datasets: [
                                            {
                                                label: dictionaryList[locale]["Confirmed"],
                                                data: data.resource.covidReportByDayRegion.map((i) => i.totalConfirmed),
                                                fill: false,
                                                borderColor: "#f7c50c"
                                            },
                                            {
                                                label: dictionaryList[locale]["Deaths"],
                                                data: data.resource.covidReportByDayRegion.map((i) => i.totalDeaths),
                                                fill: false,
                                                borderColor: "#f70c0c"
                                            }
                                        ]
                                    }} key={uuid()} />

                                </div>
                            </div>
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
                        </>
                    }

                </div>
            )}

        </>
    )
}

export default RegionDetail;