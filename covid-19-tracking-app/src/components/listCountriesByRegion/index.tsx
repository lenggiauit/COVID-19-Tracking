import React, { useState, useCallback } from 'react';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import { useGetTopByCountryQuery } from '../../services/getTopByCountry';
import LocalSpinner from "../localSpinner";
import { GetRandomBgColor } from '../../utils/functions';
import { Covid19DataByCountry, DetailByCountryRequest } from '../../types/covid19DataByCountry';
import { uuid } from 'uuidv4';
//@ts-ignore
import { Scrollbars } from 'react-custom-scrollbars';
import { useHistory } from "react-router-dom";
import CountryItem from './countryItem';
import { Covid19DataByRegion } from '../../types/covid19DataByRegion';
import { useGetCountriesByRegionQuery } from '../../services/getCountriesByRegion';
import { CovidReportDetailRequest } from '../../types/covidReportDetailRequest';

type Props = {
    region: Covid19DataByRegion
}
const ListCountriesByRegion: React.FC<Props> = ({ region }) => {


    const defaultPayload = {
        regionCode: region.regionCode
    };

    const [payload, setPayload] = useState<CovidReportDetailRequest>(defaultPayload);
    const { data, error, isFetching, isLoading } = useGetCountriesByRegionQuery({ payload: payload });

    const history = useHistory();
    const selectedCountryHandler = (item: Covid19DataByCountry) => {
        history.push('/country', item);
    }

    return (
        <>
            <bt.Row>
                <bt.Col  >

                    {(isFetching || isLoading) && (
                        <bt.Placeholder as="a" animation="glow">
                            <bt.Placeholder xs={5} bg={GetRandomBgColor()} size="lg" />
                        </bt.Placeholder>)}
                    {!error && !isFetching && <h5> <Translation tid="CountriesList" /> </h5>}

                </bt.Col>
            </bt.Row>
            <bt.Row>
                <bt.Col >
                    {(isFetching || isLoading) &&
                        <>{
                            Array.from(Array(7).keys()).map((i) => (
                                <>
                                    <CountryItem key={uuid()} max={1} selectedItem={() => { }} />
                                </>
                            ))
                        }
                        </>
                    }
                    {error && <div>{JSON.stringify(error)}</div>}
                    {!error && !isFetching && data?.success && data?.resource != null &&
                        <> {
                            <>
                                <Scrollbars style={{ height: 690 }}>

                                    {data?.resource.map((item) => (
                                        <>
                                            <CountryItem key={uuid()} selectedItem={selectedCountryHandler} data={item} max={Math.max.apply(Math, data?.resource.map(function (o) { return o.confirmed; }))} />
                                        </>
                                    ))}

                                </Scrollbars>
                            </>
                        }
                        </>
                    }
                </bt.Col>
            </bt.Row>
        </>
    )
}

export default ListCountriesByRegion;