import React, { useEffect, useState } from 'react';
import { GetCurrentCountry, GetRandomBgColor } from '../../utils/functions';

import { useGetCurrentCountryQuery } from '../../services/getCurrentCountry';
import { useGetByCountryQuery } from '../../services/getByCountry';
import { DetailByCountryRequest } from '../../types/covid19DataByCountry';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
//@ts-ignore
import ReactCountryFlag from "react-country-flag";
import { KeyValues } from '../../locales/';

const CurrentCountry: React.FC = () => {
    const currentCountryCode = useGetCurrentCountryQuery().data?.countryCode || "VN";
    let start = new Date();
    start.setDate(new Date().getDate() - 7)
    const defaultPayload = {
        countryCode: currentCountryCode,
        startDate: start,
        endDate: new Date(),
    };

    const [payload, setPayload] = useState<DetailByCountryRequest>(defaultPayload);
    const { data, error, isFetching, isLoading } = useGetByCountryQuery({ payload: payload });

    return (
        <>
            <bt.Container>
                <bt.Row>
                    <bt.Col md={12} >
                        {(isFetching || isLoading) && (
                            <bt.Placeholder as="a" animation="glow">
                                <bt.Placeholder xs={5} bg={GetRandomBgColor()} size="lg" />
                            </bt.Placeholder>)}
                        {!error && !isFetching && <h5> <Translation tid="Situation_by_Current_Country" /> </h5>}

                    </bt.Col>
                </bt.Row>
                <bt.Row>
                    <bt.Col md={12} >
                        {(isFetching || isLoading) &&
                            <>{
                                <bt.Placeholder as="a" animation="glow">
                                    <bt.Placeholder xs={5} bg={GetRandomBgColor()} size="lg" />
                                </bt.Placeholder>
                            }
                            </>
                        }
                        {error && <div>{JSON.stringify(error)}</div>}
                        {!error && !isFetching && data?.success &&
                            <>
                                <div className="country-item-body my-4 bg-info rounded p-2"  >
                                    <div className="d-flex justify-content-between">
                                        <div>
                                            <ReactCountryFlag className="emojiFlag"
                                                svg
                                                style={{
                                                    width: '3em',
                                                    height: '3em',
                                                }}
                                                title={KeyValues["country"][data?.resource.countryCode]}
                                                countryCode={data?.resource.countryCode} />&nbsp;
                                            <span className="text-left" >
                                                <b>{KeyValues["country"][data?.resource.countryCode]} </b>
                                            </span>
                                        </div>
                                        <div>
                                            <b><span className="text-warning">
                                                {data?.resource.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })} </span>
                                                /
                                                <span className="text-danger"> {data?.resource.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</span>&nbsp;
                                                (<span>{((data?.resource.deaths / data?.resource.confirmed) * 100).toFixed(2)} %</span>)
                                            </b>
                                        </div>

                                    </div>
                                    <div className="d-flex justify-content-between">
                                        <div></div>
                                        &nbsp;
                                        <small style={{ fontSize: 10 }}>
                                            <Translation tid="Confirmed" /> / <Translation tid="Deaths" />
                                        </small >
                                    </div>

                                </div>
                            </>
                        }
                    </bt.Col>
                </bt.Row>
            </bt.Container>
        </>
    )

}
export default CurrentCountry;