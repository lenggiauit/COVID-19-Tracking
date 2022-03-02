import React, { useState, useCallback } from 'react';
import * as bt from 'react-bootstrap';
import { Translation } from '../translation';
import { useGetTopByCountryQuery } from '../../services/getTopByCountry';
import LocalSpinner from "../localSpinner";
import { GetRandomBgColor } from '../../utils/functions';
import { Covid19DataByCountry } from '../../types/covid19DataByCountry';
import { uuid } from 'uuidv4';
import TopCountriesItem from './topCountryItem';
//@ts-ignore
import { Scrollbars } from 'react-custom-scrollbars';
import { useAppSelector, useAppDispatch } from '../../store/hooks';
import { selectCountry } from './selectedCountrySlice';
import { useHistory } from "react-router-dom";

const TopCountry: React.FC = () => {
    const dispatch = useAppDispatch();
    const { data, error, isFetching, isLoading } = useGetTopByCountryQuery();
    const [selectedCountry, setSelectedCountry] = useState<Covid19DataByCountry>();
    const count = useAppSelector(state => state.selectedCountry.value)
    const history = useHistory();
    const selectedCountryHandler = (item: Covid19DataByCountry) => {
        history.push('/country', item);
    }

    return (
        <>
            <bt.Row>
                <bt.Col  >
                    <h5> <Translation tid="Situation_by_WHO_TopCountries" /> </h5>
                </bt.Col>
            </bt.Row>
            <bt.Row>
                <bt.Col >
                    {(isFetching || isLoading) &&
                        <>{
                            Array.from(Array(7).keys()).map((i) => (
                                <>
                                    <TopCountriesItem key={uuid()} max={1} selectedItem={() => { }} />
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
                                            <TopCountriesItem key={uuid()} selectedItem={selectedCountryHandler} data={item} max={Math.max.apply(Math, data?.resource.map(function (o) { return o.confirmed; }))} />
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

export default TopCountry;