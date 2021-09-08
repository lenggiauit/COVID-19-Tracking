import React, { useEffect, useState } from 'react';
import { GetCurrentCountry, GetRandomBgColor } from '../../utils/functions';

import { useGetCurrentCountryQuery } from '../../services/getCurrentCountry';
import { useGetTotalCaseByCountryQuery } from '../../services/getTotalCaseByCountry';
import { Covid19DataByCountry, DetailByCountryRequest } from '../../types/covid19DataByCountry';
import { CurrentCountry } from '../../types/currentCountry';

import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
//@ts-ignore
import ReactCountryFlag from "react-country-flag";
import { KeyValues } from '../../locales/';
import { useHistory } from "react-router-dom";

type Props = {
    cc: CurrentCountry
}
const ByCurrentCountry: React.FC<Props> = ({ cc }) => {
    const history = useHistory();
    const selectedCountryHandler = (item: Covid19DataByCountry) => {
        history.push('/country', item);
    }
    let start = new Date();
    start.setDate(new Date().getDate() - 7)
    const defaultPayload = {
        countryCode: cc.countryCode
    };

    const [payload, setPayload] = useState<DetailByCountryRequest>(defaultPayload);
    const { data, error, isFetching, isLoading } = useGetTotalCaseByCountryQuery({ payload: payload });

    return (
        <>
            <bt.Container>
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
                        {!error && !isFetching && data?.success && data?.resource != null &&
                            <>
                                <div className="d-flex justify-content-between p-3 my-3 text-white bg-info rounded shadow-sm" style={{ cursor: "pointer" }}
                                    onClick={() => selectedCountryHandler(data?.resource)}>
                                    <div className="d-flex justify-content-between">
                                        <ReactCountryFlag className="emojiFlag"
                                            svg
                                            style={{
                                                width: '3em',
                                                height: '3em',
                                            }}
                                            title={KeyValues["country"][data?.resource.countryCode]}
                                            countryCode={data?.resource.countryCode} />&nbsp;


                                        <div className="lh-1  ml-3">
                                            <h1 className="h4 mb-0 text-white lh-1">{KeyValues["country"][data?.resource.countryCode]}</h1>
                                            <small>IP: {cc.query}</small>
                                        </div>
                                    </div>

                                    <div>
                                        <b><span className="text-warning">
                                            {data?.resource.confirmed.toLocaleString(undefined, { maximumFractionDigits: 0 })} </span>
                                            /
                                            <span className="text-danger"> {data?.resource.deaths.toLocaleString(undefined, { maximumFractionDigits: 0 })}</span>&nbsp;
                                            (<span>{((data?.resource.deaths / data?.resource.confirmed) * 100).toFixed(2)} %</span>)
                                        </b>
                                        <div>
                                            &nbsp;
                                            <small style={{ fontSize: 12 }}>
                                                <Translation tid="Confirmed" /> / <Translation tid="Deaths" />
                                            </small >
                                        </div>
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
export default ByCurrentCountry;